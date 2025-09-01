﻿namespace Notes.Models
{
    public class Note
    {
        public string Filename { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
        public string PhotoPath { get; set; } = string.Empty;
        public DateTime Date { get; set; }
    }
}
