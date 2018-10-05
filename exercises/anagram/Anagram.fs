module Anagram

open System

let buildMap target = 
    target 
    |> Seq.fold(fun map c -> 
        let char = c |> Char.ToLowerInvariant
        match map |> Map.tryFind char with
        | Some value -> map |> Map.remove char |> Map.add char (value + 1)
        | None -> map |> Map.add char 1) Map.empty

let useChar c map = 
    let matchChar m = 
        let char = c |> Char.ToLowerInvariant
        match m |> Map.tryFind char with
        | Some value -> 
            if value = 1 then m |> Map.remove char |> Some
            else m |> Map.remove c |> Map.add char (value - 1) |> Some
        | None -> None
    Option.bind matchChar map

let findAnagrams sources target = 
    let map = buildMap target
    sources |> List.where (fun source ->
        if String.Equals(source, target, StringComparison.InvariantCultureIgnoreCase) then false
        else
            let state = Some(map)
            let rez = source |> Seq.fold (fun map char -> useChar char map) state 
            match rez with
            | Some map -> map.IsEmpty 
            | None -> false)