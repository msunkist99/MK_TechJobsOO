namespace TechJobs.Models
{
    public class Employer : JobField
    {
        // No additional members yet. See JobField.cs

        private static int nextId = 0;

        public Employer ()
        {
            ID = nextId;
            nextId++;
        }
    }
}
