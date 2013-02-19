using RedBlack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace RedBlackWeb
{
    public partial class Tree : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                string url = String.Format("Tree.aspx?values={0}", HttpUtility.UrlEncode(Values.Text));
                Response.Redirect(url);
            }

            string values = "q\nw\ne\nr\nt\ny\n-\nq";

            if (!String.IsNullOrEmpty(Request.QueryString["values"]))
                values = Request.QueryString["values"];

            string code = GetGraphCode(values);
            string data = GetGraphData(code);

            Values.Text = values;
            Code.Text = code;
            Graph.ImageUrl = String.Format("data:image/png;base64,{0}", data);
        }

        string GetGraphCode(string values)
        {
            IEnumerable<string> keys =
                from key in values.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None)
                where !String.IsNullOrEmpty(key.Trim()) select key.Trim();

            var tree = new Tree<Student>();
            bool add = true;

            foreach (string key in keys)
            {
                if (key == "-")
                {
                    add = false;
                    continue;
                }

                if (key == "+")
                {
                    add = true;
                    continue;
                }

                if (add)
                    tree.Add(new Student(key));
                else
                    tree.Remove(key);
            }

            return tree.GetDotCode();
        }

        string GetGraphData(string dot)
        {
            Graph graph = new Graph(dot);
            string data = graph.GetBase64();

            return data;
        }
    }
}