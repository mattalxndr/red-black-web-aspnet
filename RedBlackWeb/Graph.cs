using System;
using System.IO;
using System.Diagnostics;
using GraphVizWrapper.Queries;
using GraphVizWrapper.Commands;
using RedBlack;

namespace RedBlackWeb
{
    public class Graph
    {
        string dot;

        public Graph(string dot)
        {
            this.dot = dot;
        }

        public string GetBase64()
        {
            byte[] bytes = GetPngData();

            string base64 = Convert.ToBase64String(bytes);

            return base64;
        }

        byte[] GetPngData()
        {
            var getStartProcessQuery = new GetStartProcessQuery();
            var getProcessStartInfoQuery = new GetProcessStartInfoQuery();
            var registerLayoutPluginCommand = new RegisterLayoutPluginCommand(getProcessStartInfoQuery, getStartProcessQuery);

            var wrapper = new GraphVizWrapper.GraphVizWrapper(getStartProcessQuery, getProcessStartInfoQuery, registerLayoutPluginCommand);

            byte[] output = wrapper.GenerateGraph(dot, GraphVizWrapper.Enums.GraphReturnType.Png);

            return output;
        }
    }
}