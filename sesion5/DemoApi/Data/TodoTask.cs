public class TodoTask {
    public int Id  {get; set;}
    public string Description  {get; set;}

    public bool Important {get; set;}

    public DateTime? DoneWhen {get; set;}

    public bool IsDone  {get => DoneWhen.HasValue;}
}