// CourseCatalog: looks up a course title by its code in one step.
//
// Part E. Build this class along with the Class 3 demo.
public class CourseCatalog
{
    // that maps a course code to its title.
    private Dictionary<string, string> catalog = new Dictionary<string, string>();

    public int Count => catalog.Count;

    // Adds a course. Returns false, and changes nothing, when the code is
    // already there. Hint: one of the three ways to write does exactly this.
    public bool AddCourse(string code, string title)
    {
        if (catalog.ContainsKey(code))
        {
            return false;
        }
        catalog[code] = title;
        return true;
    }

    // Returns the title for a code, or "(no such course)" when the code is
    // missing. Use TryGetValue, so the code is looked up only once.
    public string TitleFor(string code)
    {
        if (catalog.TryGetValue(code, out string title))
        {
            return title;
        }
        return "(no such course)";
    }
}
