namespace Mirai.Nodes
{
    public class Using : INode
    {
        public Using(QualifiedId @namespace)
            : this(false, null, @namespace)
        {
        }

        public Using(bool isStatic, Id? alias, QualifiedId @namespace)
        {
            IsStatic = isStatic;
            Alias = alias;
            Namespace = @namespace;
        }

        public bool IsStatic { get; }

        public Id? Alias { get; }

        public QualifiedId Namespace { get; }
    }
}