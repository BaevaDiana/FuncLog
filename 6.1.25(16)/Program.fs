open System

let rec readList n = 
    if n=0 then []
    else
    let Head = System.Convert.ToInt32(System.Console.ReadLine())
    let Tail = readList (n-1)
    Head::Tail

let readData = 
    Console.WriteLine("Введите размерность списка:  ")
    let n=System.Convert.ToInt32(System.Console.ReadLine())
    Console.WriteLine("Введите список: ")
    readList n

//Дан массив и интервал.Найти максимальный из элементов в этом интервале

let MaxInterval (a,b) list= 
    let rec maxinterval list (a,b) max = 
        match list with
        |[]->max
        |h::tail-> 
            let newMax = 
                if h>max && h>a && h<b then h
                else max
            maxinterval tail (a,b) newMax
    maxinterval list (a,b) a

[<EntryPoint>]
let main argv =
    Console.WriteLine("Введите границы интервала:")
    let interval = (Convert.ToInt32(Console.ReadLine()),Convert.ToInt32(Console.ReadLine()))
    Console.WriteLine("Максимум на интервале:")
    readData |> MaxInterval interval|> Console.WriteLine
    0