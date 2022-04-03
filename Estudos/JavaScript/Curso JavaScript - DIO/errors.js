function CheckArray(arr, num){

    try{
        if(!arr && !num) throw new ReferenceError("Send the parameters man");

        if(!(arr instanceof Object)) throw new TypeError("First parameter must be an array");

        if(typeof num != 'number') throw new TypeError("Second parameter must be a number");

        if(arr.length != num) throw new RangeError("The array length is different than the number");

        return arr;
    } catch (e){
    
        if(e instanceof ReferenceError){

            //Just to know what can be in an error object
            /*console.log(e.message);
            console.log(e.name);
            console.log(e.stack);*/

            console.log("This is a Reference error. Did you forget the parameters?");
    
        } else if (e instanceof TypeError){ 
            console.log("First parameter must be an array. You gave the parameter as: " + typeof arr);
            console.log("Second parameter must be a number. You gave the parameter as: " + typeof num);
        } else if (e instanceof RangeError){
            console.log("The array length must be equal to the number. The array length is: "+
            arr.length + " || The number is: "+num);
        } else {
            console.log("Error not expected: " + e);
        }
    }     
}

CheckArray([1, 2, 3, 4, 5], 5);
