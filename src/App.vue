<script setup>
  import { ref, onMounted, computed, watch } from 'vue'

  const todos = ref([])
  const name = ref('')

  const input_content = ref('')
  const input_desc = ref('')

  const todos_asc = computed(() => todos.value.sort((a,b) =>{
    return a.createdAt - b.createdAt
  }))

  watch(name, (newVal) => {
    localStorage.setItem('name', newVal)
  })

  watch(todos, (newVal) => {
    localStorage.setItem('todos', JSON.stringify(newVal))
  }, {
    deep: true
  })

  const addTodo = () => {
    if (input_content.value.trim() === '') {
      return
    }

    todos.value.push({
      content: input_content.value,
      desc: input_desc.value, 
      done: false,
      editable: false,
      createdAt: new Date().getTime()
    })

    input_content.value = '' 
    input_desc.value = ''
  }

  const removeToDo = todo => {
    todos.value = todos.value.filter(t => t !== todo)
  }

  onMounted(() => {
    name.value = localStorage.getItem('name') || ''
    todos.value = JSON.parse(localStorage.getItem('todos')) || []
  })
</script>

<template>
	<main class="app">
		
		<section class="greeting">
			<h2 class="title">
				What's up, <input type="text" id="name" placeholder="Name here" v-model="name">
			</h2>
		</section>

		<section class="create-todo">
			<h3>CREATE A TODO</h3>

			<form id="new-todo-form" @submit.prevent="addTodo">
				<h4>What's on your todo list?</h4>
				<input 
					type="text" 
					name="content" 
					id="content" 
					placeholder="e.g. get groceries"
					v-model="input_content" />
				
				<h4>Description</h4>
				<input 
          type="text"
          name="desc"
          id="desc"
          placeholder="e.g. Milk, eggs, butter"
          v-model="input_desc"
        />

				<input type="submit" value="Add todo" />
			</form>
		</section>

    <section class="todo-list">
      <h3>To-Do List</h3>
      <div class="list">
        <div v-for="todo in todos_asc" :class="`todo-item ${todo.done && 'done'}`">
          <label>
            <input type="checkbox" v-model="todo.done"/>
            <span class="bubble personal"></span>
          </label>

          <div class="todo-content">
            <input type="text" v-model="todo.content">
          </div>

          <div class="todo-desc">
            <input type="text" v-model="todo.desc">
          </div>

          <div class="actions">
            <button class="delete" @click="removeToDo(todo)">Delete</button>
          </div>
        </div>
      </div>
    </section>
	</main>
</template>