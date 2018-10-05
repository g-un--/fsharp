module Acronym

open System

let abbreviate (phrase : string) = 
    let noise = 
        phrase
        |> Seq.where<Char>(fun c -> Char.IsPunctuation(c) || Char.IsWhiteSpace(c))
        |> Seq.distinct
        |> Seq.toArray
    let rez = 
        phrase.Split(noise, StringSplitOptions.RemoveEmptyEntries) 
        |> Seq.map(fun s -> s.[0])
        |> Seq.map(Char.ToUpper)
        |> Seq.toArray
        |> String
    rez