﻿namespace Notes.Models;

public class Note
{
    public string Filename { get; set; }
    public string Text { get; set; }
    public DateTime Date { get; set; }
    public string PhotoPath { get; set; } // New: path to the note image
}