open System

let rec readList n = 
    if n=0 then []
    else
    let Head = System.Convert.ToInt32(System.Console.ReadLine())
    let Tail = readList (n-1)
    Head::Tail

let readData1 = 
    Console.WriteLine("Введите размерность первой последовательности:  ")
    let n=System.Convert.ToInt32(System.Console.ReadLine())
    Console.WriteLine("Введите первую последовательность: ")
    readList n

let readData2 = 
    Console.WriteLine("Введите размерность второй последовательности:  ")
    let n=System.Convert.ToInt32(System.Console.ReadLine())
    Console.WriteLine("Введите вторую последовательность: ")
    readList n
 

let rec writeList = function
    [] ->   let z = System.Console.ReadKey()
            0
    | (head : int)::tail -> 
                       System.Console.WriteLine(head)
                       writeList tail

//Даны две последовательности, найти наибольшую по длине общую подпоследовательность.


let circleLeft (list: 'int list) =
    list.Tail @ [list.Head]

//поиск общей подпоследовательности
let FindSeq list1 list2=
    fst (List.fold2 (fun s x1 x2->
        if x1=x2 then
            let new_c = (snd s)@[x1]
            if List.length new_c >= List.length (fst s) then
                (new_c, new_c)
            else 
                (fst s, new_c)
        else
            (fst s, [])    
    ) ([], []) list1 list2)

//поиск наибольшей последовательности
let FindMaxSeq list1 list2 = 
    let rec findmaxseq list1 list2 iter (seq:'int List)= 
        if iter=List.length list2 then seq
        else 
            let newSeq =
                if List.length seq<List.length (FindSeq list1 list2) then FindSeq list1 list2
                else seq
            findmaxseq list1 (circleLeft list2) (iter+1) newSeq
    findmaxseq list1 list2 1 []
            

[<EntryPoint>]
let main argv =
    let list1= readData1
    let list2= readData2
    Console.WriteLine("Наибольшая по длине общая подпоследовательнсоть:")
    let ResultList = FindMaxSeq list1 list2
    writeList ResultList
    0