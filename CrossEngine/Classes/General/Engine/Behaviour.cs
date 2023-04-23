
namespace CrossEngine
{
    public class Behaviour 
    {
        public Behaviour()
        {
            enabled = true;
        }

        //
        // Summary:
        //     Enabled Behaviours are Updated, disabled Behaviours are not.
        public bool enabled { get; set; }
    }
}
