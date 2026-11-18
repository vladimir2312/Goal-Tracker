namespace TelegrammMiniApp.Models
{
    public class Goal
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string? Description { get; set; }      
        public double CurrentValue { get; set; }       // текущий прогресс
        public double TargetValue { get; set; }        // цель
        public string? Unit { get; set; }

    }
}
