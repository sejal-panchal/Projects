//creating object
//factories and constructors
//primitives and ref types
//working with prop
//private prop
//Getter & setters


//let is replacement of var; stop using var because of scoping issue.
//use const to define constants.


//circle object ; pay attention its not class.
const circle={
    radius:1,
    location:{
        x:1,
        y:1
    },
    draw:function(){
        console.log('draw');
    }
};

circle.draw();

//object can be define with factories and constructors.
//if object have behaviour i.e. if object have method then we want to create object using factories / constructors.
//the reason is if object have function.
// if you want to create multiple objects , 
//you may copy paste but if there is a change in logic 
//then there change required on multiple places. 

// In short : duplication is not a good way to create object.

//1.factory function
function createCircle(radius){
    return {
        radius,
        draw:function(){
            console.log('draw');
        }
    };
}

const factoryCircle=createCircle(1);
factoryCircle.draw();

//Constructor function
function ConCircle(radius){
    this.radius=radius;
    this.draw = function(){
        console.log('draw');
    }
}
const another = new ConCircle(1);

//diff betwn these two patterns. both patterns are needed.
//any pattern can be chosen.
//in javascript we dont have class.

//object literal
let x={};

// internally, its let x = new object{};
//new String(); we use '', "",``(back ticks).
//new Boolean(); but we use true, false.

//In OOP - javascript functions are objects.

const Circle1 = new Function('radius',`
    this.radius=radius;
    this.draw = function(){
        console.log('draw');
    }
    `);

    const circleObj= new Circle1(1);


    //call() method to call function.
    //it has args, 1st arg is this-> target, it mean this object.
    //below line 84 is same as line 78.
    ConCircle.call({},1);

    //apply() => for second argument if you have array. Use apply function.
    //ConCircle.apply({},[1,2,3]);

    //categoreis of type 1. value types and ref types
    // value type: number , string, boolean, symbol, undefined, null.
    //ref types: object, function, arrays.

//to understand about prototypes we need to understand how primitives and objects behave differently.

//define primitives
let x1=10;
let y1=x1;
x1=20;

//line 117 : x=20 and y=10, even when we copy y to x but as they are completely different variable, value remains different.

//define reference types
let x_prim={value:10};
let y_prim=x_prim;
x_prim.value=20;
//takeway:In chrome f12, watch line 126 object is not stored in variable , only address/ref stored in variable and when we copy x=y both reference same address. so the value becomes same.

//so the difference is 
//primitives are copied by their value, objects are copied by their reference.

//another example:
let number =10;
function increase(number){
    number++ //this number will go out of scope and will not retain changes.
}
increase(number);
console.log(number);

//changes above example to ref type.
let obj ={value:10};
function increase(obj){
    obj.value++ //this number will go out of scope and will not retain changes.
}
increase(obj);
console.log(obj);
//------------------------------------------------
//objects in js are dynamic. we can add and remove properties on the fly on the server.
//as we do not have classes we donot have to worry to add them in the class.

ConCircle.location={x:1};

//another notation is using brackets [], use this notation when you have special characters in propertyName.
ConCircle['location']={x:1};
const propertyName='location';
ConCircle[propertyName]={x:1};


//we dont want to send any property which is data sensitive.
//we can delete on the fly on the server.
delete ConCircle.location; //and we can use both the notation dot . or brackets ['location']

//sometimes we need to enumerate properties 
for (let key in ConCircle){
    if(typeof ConCircle[key]!=='function') //this will prevent showing functions to client
    console.log(key,ConCircle[key]); //also shows value of properties.
}

//another way to do as above 
const keys=Object.keys(ConCircle);
console.log(keys);

//check if property or method exists with in operator.

if('radius' in ConCircle)
    console.log('Circle has a radius');

//define circle for another example And we make it more complex:
//how to apply abscration.
//mechanism works by showing only essential and hide all detailed complexity.
function ConCircle2(radius){
    //only show radius
    this.radius=radius;
    //add another function
    this.defaultLocation={x:0,y:0};
 
    //yet another function
    this.computeOptimumLocation=function(){
        //...
    }

    // and also show draw method.
    this.draw = function(){
        this.computeOptimumLocation();
        console.log('draw');
    }
}

const tryCircle= new ConCircle2(10);
//above example is problematic.


//
function ConCircle2(radius){
    //only show radius
    this.radius=radius;
    
    let defaultLocation={x:0,y:0}; //defining this function as local variable instead of "this.function" which is property is only to hide the implementation (following abscration).
 
    
    let computeOptimumLocation=function(factor){
        //...
    }

    // and also show draw method.
    this.draw = function(){
        //note: concept of closure:
        let x,y; //this will go out of scope and dies once the draw function is closed.
        //in contrast to scope we have closure.
        //a closure determins what variable are accessible to inner functions, so this draw function will be able to utilise all variables defined in this function and also from parent function.
        //like computeOptimumLocation.
        //scope is temporary and dies but closure stays there.
       computeOptimumLocation(0.1); // we can call this function directly by concept of `Closure`
        console.log('draw');

       

    }
     //shows value of private members
     this.getDefaultLocation = function (){
        return defaultLocation;
    };
    
    //how to show private member values with property.
    //also to define property with setters and getters
    Object.defineProperty(this,'defaultLocation',{
        get: function(){
            //this lets you get the property. read only property; do not set setter
            return defaultLocation;
        },
        set:function(value){
            if(!value.x || !value.y)
            throw new Error('Invalid location.');
            defaultLocation=value;
        }
    });

}

const tryCircle2= new ConCircle2(10);
tryCircle.draw();


