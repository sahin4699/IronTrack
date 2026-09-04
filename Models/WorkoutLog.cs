namespace WorkoutTrackerApi.Models;

public class WorkoutLog
{
    public int Id { get; set; }

    // Örn: "Bench Press", "Squat"
    public string ExerciseName { get; set; } = string.Empty;

    // Kaldırılan ağırlık (kg)
    public double Weight { get; set; }

    // Kaç tekrar yapıldı
    public int Reps { get; set; }

    // Kaçıncı set olduğu
    public int SetNumber { get; set; }

    // Antrenman tarihi
    public DateTime Date { get; set; } = DateTime.UtcNow;
}