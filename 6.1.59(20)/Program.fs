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

let rec writeList = function
    [] ->   let z = System.Console.ReadKey()
            0
    | (head : int)::tail -> 
                       System.Console.WriteLine(head)
                       writeList tail 
//Дан список.Построить новый список из квадратов неотрицательных чисел,меньших 100 и встречающихся в массиве больше 2 раз

//частота встречаемости
let Count elem list= 
    let rec count list el num = 
        match list with 
        |[]->num
        |h::tail->
            let newNum = if el=h then (num+1)else num
            count tail el newNum
    count list elem 0
 

let filter predicate f list  =
    let rec filt list pr newList = 
        match list with
        |[]->newList
        |h::tail ->
            let nextNewList = 
                if pr h then (newList @ [f h])
                else newList
            filt tail pr nextNewList
    filt list predicate []


let delEL list el = filter (fun x -> (x <> el)) (fun x->x) list 
let uniq list = 
    let rec uniq1 list newList = 
        match list with
            |[] -> newList
            | h::t -> 
                        let listWithout = delEL t h
                        let newnewList = newList @ [h]
                        uniq1 listWithout newnewList
    uniq1 list [] 

[<EntryPoint>]
let main argv =
    let l = readData
    Console.WriteLine("Получившийся список:")
    filter (fun x -> x<100 && x>0 && (Count x l)>2) (fun x -> x*x) l|>uniq |>writeList
    0 