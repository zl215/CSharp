using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

#region zhouliang
namespace ConsoleApplication1
{
    enum ENodeType
    {
        NodeInterface,
        NodeClass,
        NodeUnknown
    }
    class Node
    {
        public Dictionary<String,Node> SubNodes;
        public ENodeType NodeType;
        public String Name;
        public Type TypeStruct;
        public Node(Type type)
        {
            if (type.IsClass)
            {
                NodeType = ENodeType.NodeClass;
            }
            else if (type.IsInterface)
            {
                NodeType = ENodeType.NodeInterface;
            }
            else
            {
                NodeType = ENodeType.NodeUnknown;
            }
            Name = type.ToString();
            TypeStruct = type;
            SubNodes = new Dictionary<string, Node>();
        }
    }
    class Program
    {
        static void PrintAllSubNodes(Node node)
        {
            Console.WriteLine(node.Name);
            foreach (var v in node.SubNodes)
            {
                PrintAllSubNodes(v.Value);
            }
        }
        static void WriteAllSubNodes(ref string s,Node node)
        {
            s += node.Name + "*,";
            foreach (var v in node.SubNodes)
            {
                WriteAllSubNodes(ref s,v.Value);
            }
        }
        static void GenerateCmdFile(string cfgPath,string cmdFile,Dictionary<String,Node> mapNodes)
        {
            StreamReader sr = new StreamReader(cfgPath, Encoding.Default);
            String line;
            FileStream fs = new FileStream(cmdFile, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            //开始写入
            string content = "co \"projectfile=C:\\DNO\\1.obproj\" \"rule=targets:All;features:Renaming;pattern:";
            
            Node nodeHead = null;
            while ((line = sr.ReadLine()) != null)
            {
                if (mapNodes.ContainsKey(line.ToString()))
                {
                    nodeHead = mapNodes[line.ToString()];
                    WriteAllSubNodes(ref content, nodeHead);
                }
            }
            content = content.Substring(0, content.Length - 1);
            content += "\"";
            sw.Write(content);
            //清空缓冲区
            sw.Flush();
            //关闭流
            sw.Close();
            fs.Close();
        }
        static void Main(string[] args)
        {
            Assembly asm = Assembly.Load("Assembly-CSharp");
	        Type[] ty = asm.GetTypes();
            Dictionary<String,Node> mapNodes = new Dictionary<String, Node>();
            foreach (var v in ty)
            {
                string name = v.ToString();
                Node nd = null;
                if (mapNodes.ContainsKey(name))
                {
                    nd = mapNodes[name];
                }
                else
                {
                    if (v.IsClass || v.IsInterface)
                    {
                        nd = new Node(v);
                        //MethodInfo[] methods = v.GetMethods();
                        mapNodes.Add(name, nd);
                    }
                    else
                    {
                        continue;
                    }
                }

                if (v.BaseType != null)
                {
                    string nameBase = v.BaseType.ToString();
                    Node ndBase = null;
                    if (mapNodes.ContainsKey(nameBase))
                    {
                        ndBase = mapNodes[nameBase];
                    }
                    else
                    {
                        ndBase = new Node(v.BaseType);
                        mapNodes.Add(nameBase,ndBase);
                    }
                    if (!ndBase.SubNodes.ContainsKey(v.ToString()))
                    {
                        ndBase.SubNodes.Add(v.ToString(), nd);
                    }
                }
                Type[] ty2 = v.GetInterfaces();
                foreach (var v2 in ty2)
                {
                    string nameItf = v2.ToString();
                    Node ndItf = null;
                    if (mapNodes.ContainsKey(nameItf))
                    {
                        ndItf = mapNodes[nameItf];
                    }
                    else
                    {
                        ndItf = new Node(v2);
                        mapNodes.Add(nameItf, ndItf);
                    }
                    if (!ndItf.SubNodes.ContainsKey(v2.ToString()))
                    {
                        ndItf.SubNodes.Add(v2.ToString(), nd);
                    }
                }
            }//foreach
            //Node nodeMonoBehaviour = mapNodes["UnityEngine.MonoBehaviour"];
            //PrintAllSubNodes(nodeMonoBehaviour);
            //Console.WriteLine("");
            //Node nodeNoviceGuideManager = mapNodes["NoviceGuideManager"];
            //PrintAllSubNodes(nodeNoviceGuideManager);
            GenerateCmdFile("skip.txt","cmd.bat",mapNodes);

        }
    }
}
#endregion