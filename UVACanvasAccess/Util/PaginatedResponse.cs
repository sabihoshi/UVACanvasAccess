namespace UVACanvasAccess.Util {
    
    /// <summary>
    /// Indicates that the return value of this method is paginated, and must be accumulated or otherwise handled.
    /// </summary>
    [System.AttributeUsage(System.AttributeTargets.Method)]
    public class PaginatedResponse : System.Attribute { }
}