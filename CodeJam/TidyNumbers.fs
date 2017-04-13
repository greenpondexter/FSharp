open System.IO
open System


let isTidy (number:Int64) = 
   
   let numArray = number.ToString().ToCharArray()  
   Array.toSeq numArray
   |> Seq.sort 
   |> Seq.toArray          
   |> Array.forall2 (fun elm1 elm2 -> elm1 = elm2) numArray                  

let findTidy number caseNum = 
    let mutable num = int64(number)   
    let mutable continue = true 

    while continue && num > int64(0) do
       let tidy = isTidy num
       if tidy then continue <- false
               else num <- num - int64(1) 


    let finalOutput = "Case #" + caseNum.ToString()+":"+" "+ num.ToString()
    finalOutput 
    

let readFile fileName = 
   
    let file = File.ReadLines(fileName)
    let totalCases = file |> Seq.head |> int 
    let mutable lineNum = 0
       
    let finalOutput =
        file
        |> Seq.toList
        |> List.tail
        |> List.map (fun x -> lineNum <- lineNum + 1
                              findTidy x lineNum 
                    )
        |> List.toArray

    File.WriteAllLines("Results.txt", finalOutput)


[<EntryPoint>]
let main argv =
    let fileName = "B-small-attempt1.in" 
    readFile fileName  
    0 



