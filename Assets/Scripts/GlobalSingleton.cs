public class GlobalSingleton<T> where T : GlobalSingleton<T>, new() {
    private static T instance = new T();
    public static T Instance { get { return instance; } }
    public static T I { get { return instance; } }
}