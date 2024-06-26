﻿using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MvvmLesson.Models;

public class Car : INotifyPropertyChanged
{
    private string? model;
    private string? make;
    private DateTime? year;
    private int? passengers;

    public string? Model { get => model; set { model = value; OnPropertyChanged(); } }
    public string? Make { get => make; set { make = value; OnPropertyChanged(); } }
    public DateTime? Year { get => year; set { year = value; OnPropertyChanged(); } }
    public int? Passengers { get => passengers; set { passengers = value; OnPropertyChanged(); } }


    public Car(string? model, string? make, DateTime? year, int? passengers)
    {
        Model = model;
        Make = make;
        Year = year;
        Passengers = passengers;
    }
    public Car(Car? car)
    {
        Model = car?.Model;
        Make = car?.Make;
        Year = car?.Year;
        Passengers = car?.Passengers;
    }
    public Car()
    {

    }

    public override string ToString()
    {
        return $"{Year} {Make} {Model} with {Passengers} passengers";
    }

    // Set Car
    public void SetCar(Car? car)
    {
        Model = car?.Model;
        Make = car?.Make;
        Year = car?.Year;
        Passengers = car?.Passengers;
    }


    // == Operator overloading
    public static bool operator ==(Car? car1, Car? car2)
    {
        if (car1 is null || car2 is null)
            return false;
        return car1.Model == car2.Model && car1.Make == car2.Make && car1.Year == car2.Year && car1.Passengers == car2.Passengers;
    }

    public static bool operator !=(Car? car1, Car? car2)
    {
        if (car1 is null || car2 is null)
            return false;
        return !(car1.Model == car2.Model && car1.Make == car2.Make && car1.Year == car2.Year && car1.Passengers == car2.Passengers);
    }


    // -----------------------------------------------------------
    public event PropertyChangedEventHandler? PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    // -----------------------------------------------------------
}
