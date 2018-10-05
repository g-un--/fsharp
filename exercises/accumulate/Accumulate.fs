module Accumulate

let accumulate (func: 'a -> 'b) (input: 'a list): 'b list = 
    let rec map f = function
    | head::tail -> f head :: map f tail
    | [] -> [] 
    map func input
