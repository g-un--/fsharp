module Allergies

open System

[<Flags>]
type Allergen = 
    | Eggs = 1
    | Peanuts = 2
    | Shellfish = 4
    | Strawberries = 8
    | Tomatoes = 16
    | Chocolate = 32
    | Pollen = 64
    | Cats = 128

let allergicTo (codedAllergies : int) (allergen : Allergen) = 
    codedAllergies &&& (allergen |> int) >= 1

let list codedAllergies = 
    Enum.GetValues(typeof<Allergen>) :?> (Allergen array)
    |> Seq.ofArray 
    |> Seq.where(fun x -> 
        let res = codedAllergies &&& (x |> int) 
        res >= 1)
    |> List.ofSeq
    |> List.map (fun id -> id)