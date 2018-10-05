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
    let allergies = codedAllergies |> enum<Allergen>
    allergies.HasFlag(allergen)

let list codedAllergies = 
    let allergies = codedAllergies |> enum<Allergen>
    Enum.GetValues(typeof<Allergen>) :?> (Allergen array)
    |> Seq.ofArray 
    |> Seq.where(fun x -> allergies.HasFlag(x))
    |> List.ofSeq