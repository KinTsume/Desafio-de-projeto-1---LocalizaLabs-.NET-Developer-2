//This script is to study the map, filter and reduce functions
const stringson = {
    value: 'is an astronaut'
}

const myArray = ['Feldspar', 'Gabbro', 'Chert', 'Esker', 'Solanum'];

//Without "this" argument
const mappedArray = myArray.map((item) => (item+' - is an astronaut'));
console.log('Normal: '+myArray);
console.log('Mapped: '+mappedArray);

//With "this" argument
const mappedArrayThis = myArray.map((item, stringson) => (item+' '+this.value));
console.log('Normal: '+myArray);
console.log('Mapped (this): '+mappedArrayThis);

myArray.forEach((item) => (item = '- astronaut for each'));
console.log('Normal: '+myArray);

const filterArray = myArray.filter((item)=>item.includes('er'));
console.log('filtered: '+filterArray);


const callbackfn = function(accumulator, currentvalue){
    accumulator += ', '+currentvalue;
}
const reduceArray = myArray.reduce(callbackfn, 0);
console.log('reduced: '+reduceArray);