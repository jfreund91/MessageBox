<template>
  <div id="app">
    <MessageBox msg="We're not here right now. Leave a note!"/>
  </div>
</template>

<script>
import MessageBox from './components/MessageBox.vue'

export default {
  name: 'app',
  components: {
    MessageBox
  }
}
</script>

<style>
#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
body {
  background: #2c3e50;
}

</style>
