namespace _52Learning
{
    public class Tag
    {
        public Tag(string tagName)
        {
            TagName = tagName;
        }

        public string TagName { get; set; }
        public override bool Equals(object obj)
        {
            if(obj is Tag)
            {
                return TagName == ((Tag)obj).TagName;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return TagName.GetHashCode();
        }
    }
}
