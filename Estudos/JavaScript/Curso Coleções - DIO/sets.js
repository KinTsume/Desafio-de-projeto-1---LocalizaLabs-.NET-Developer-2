//This is a study of Sets
//Sets are a collection that stores unique values

const myArray = [30, 30, 52, 48, 61, 48, 01, 48];

function uniqueValues(arr){
    const mySet = new Set(arr);
    return [...mySet]; //This is the spread operator. It turns the Set values into an array
}

console.log(uniqueValues(myArray));