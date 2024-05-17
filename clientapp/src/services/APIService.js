export async function createToDo(data){
    const response = await fetch(`/api/todo`, {
        method: 'POST', 
        headers: {'Content-Type': 'application/json'}, 
        body: JSON.stringify(data)
    })

    return await response.json(); 
}

export async function getAllToDos() {
    const response = await fetch('/api/todo_list'); 
    return await response.json(); 
}

export async function editToDo() {
    const response = await fetch(`/api/edittodo`, {
        method: 'POST', 
        headers: {'Content-Type': 'application/json'}, 
        body: JSON.stringify(data)
    })

    return await response.json(); 
}

export async function deleteToDo() {
    const response = await fetch(`/api/deltodo`, {
        method: 'POST', 
        headers: {'Content-Type': 'application/json'}, 
        body: JSON.stringify(data)
    })

    return await response.json(); 
}