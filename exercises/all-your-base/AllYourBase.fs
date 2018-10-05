module AllYourBase

let (|Valid|_|) inputBase value = 
    if inputBase >= 2 && value |> Seq.forall(fun v -> v < inputBase && v >= 0) then Some(inputBase) 
    else None

let rec pow input power rez = 
    match power with
    | 0 -> rez
    | _ -> pow input (power - 1) (rez * input)

let rec convert outputBase value rez =
    let div = value / outputBase
    let rem = value % outputBase
    if div > 0 then convert outputBase div (rem::rez)
    else (rem::rez)

let rebase (digits : seq<int>) inputBase outputBase = 
    match digits with
    | Valid inputBase validBase -> 
        let length = digits |> Seq.length
        let sum = digits 
                  |> Seq.mapi(fun index digit -> digit * (pow validBase (length - index - 1) 1)) 
                  |> Seq.sum
        if outputBase >= 2 then Some(convert outputBase sum [])
        else None
    | _ -> None