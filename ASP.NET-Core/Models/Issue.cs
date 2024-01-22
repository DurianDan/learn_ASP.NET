using System.ComponentModel.DataAnnotations;

namespace learn.Models
{  
    public class Issue(
    ){
        public int Id {get; set;}
        [Required]
        public string? Title {get; set;}
        [Required]
        public string? Description{get; set;}
        public Priority Priority {get; set;}
        public IssueType IssueType {get; set;}
        public DateTime Created {get; set;} = DateTime.UtcNow;
        public DateTime? Completed {get; set;}
    }

    public enum Priority{
        Low, Medium, High
    }
    public enum IssueType{
        Feature, Bug, Documentation
    }
}