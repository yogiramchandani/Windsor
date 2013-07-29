
//http://mikehadlow.blogspot.co.uk/2010/02/10-advanced-windsor-tricks-8-dependency.html

using Castle.Core;
using Castle.Core.Internal;
using Castle.Windsor;
using System.IO;

namespace WindsorConvention._7_Dependency_Graph
{
    public class DependencyGraphWriter
    {
        private readonly IWindsorContainer _container;
        private readonly TextWriter _writer;

        public DependencyGraphWriter(IWindsorContainer container, TextWriter writer)
        {
            _container = container;
            _writer = writer;
        }

        public void Output()
        {
            var graphNodes = _container.Kernel.GraphNodes;

            foreach (var graphNode in graphNodes)
            {
                _writer.WriteLine();
                WalkGraph(graphNode, 0);
            }
        }

        private void WalkGraph(GraphNode node, int level)
        {
            var componentModel = node as ComponentModel;
            if (componentModel != null)
            {
                _writer.WriteLine(
                "{0}{1} -> {2}",
                new string('\t', level),
                componentModel.ComponentName,
                componentModel.Implementation.FullName);
            }

            foreach (var childNode in node.Dependents)
            {
                WalkGraph(childNode, level + 1);
            }
        }
    }
}
