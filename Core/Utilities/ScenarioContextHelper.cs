using TechTalk.SpecFlow;

public static class ScenarioContextHelper
{
    /// <summary>
    /// Sets or replaces a value in the ScenarioContext.
    /// If the key already exists, it will update the value.
    /// If the key does not exist, it will add a new key-value pair.
    /// </summary>
    /// <typeparam name="T">The type of the value to be stored.</typeparam>
    /// <param name="context">The ScenarioContext instance.</param>
    /// <param name="key">The key to be added or updated.</param>
    /// <param name="value">The value to be stored.</param>
    public static void SetOrReplace<T>(ScenarioContext context, string key, T value)
    {
        if (context.ContainsKey(key))
        {
            // Remove the existing key-value pair
            context.Remove(key);
        }

        // Add the new key-value pair
        context[key] = value;
    }
}
