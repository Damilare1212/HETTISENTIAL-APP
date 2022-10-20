


const getCountry = document.querySelector("#country")
const getState = document.querySelector("#state")
const getCities = document.querySelector("#lga")
const result = document.querySelector("#state-choosen");
localGovernment.innerHTML = '<option value=""> Choose LocalGovernment</option> ';
state.innerHTML = '<option value="">Choose State</option> ';
console.log(stateChoosen)
stateChoosen.addEventListener("change", () => { 
    /*    console.log("changing...")*/
    console.log(stateChoosen.value)
   GetLocalGovernnment(stateChoosen.value);
});


let fetchAddress = async () =>{
    let a = await fetch('https://countriesnow.space/api/v0.1/countries/states');
    let b = a.json();
    return b;
}


let displayState = async () => {
    
    let c = await fetchAddress();
    let d = c.data;
    console.log(d);
    d.forEach(x =>{
        if (x.name == "Nigeria") {
            x.states.forEach(r => {
                getState.innerHTML += `<option value="${r.name}">${r.name}</option>`
            })
        }
        
    })
}


http://locationsng-api.herokuapp.com/api/v1/lgas

https://allnigeria-api.herokuapp.com/api/v1/states

fetch('https://locationsng-api.herokuapp.com/api/v1/states')



function GetState() {
    fetch('https://locationsng-api.herokuapp.com/api/v1/states')
        .then((response) => response.json())
        .then((res) => {
            console.log(res)
            res.forEach((item) => {
                console.log(item);
                state.innerHTML += ` <option value=${item.name}>${item.name}</option>`;
            })
               
        })
           
            
        
}
function GetLocalGovernnment(state)
{
    //fetch(`https://locationsng-api.herokuapp.com/api/v1/states/${state}/lgas`)
    //https://allnigeria-api.herokuapp.com/api/v1/state/lgas/${state}

    console.log(state)
    console.log(localGovernment)
    fetch(`https://locationsng-api.herokuapp.com/api/v1/states/${state}/lgas`)
        .then((response) => response.json())
        .then((res) => {
            console.log(res);
            localGovernment.innerHTML = '<option value=""> Choose LocalGovernment</option>';
            res.forEach((item) =>
                localGovernment.innerHTML += ` <option value=${item}>${item}</option>`)
        })
}
GetState();









const options = {
	method: 'GET',
	headers: {
		'X-RapidAPI-Key': '8f7e78536emsh7c0238f0712f866p1de87djsn4eaa0b252233',
		'X-RapidAPI-Host': 'nigeria-states-and-lga.p.rapidapi.com'
	}
};

fetch('https://nigeria-states-and-lga.p.rapidapi.com/lgalists', options)
	.then(response => response.json())
	.then(response => console.log(response))
	.catch(err => console.error(err));


