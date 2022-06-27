<template>
  <div>
    <div class="content-title">
      <h1>Стэк используемых технологий</h1>
    </div>

    <div class="content-inp">
      <hr>
      <h2>Front:</h2>
      <p>- Vue.js</p>
      <p>- Typescript</p>
      <p>- Axios</p>
      <hr>
      <h2>Backend</h2>
      <p>- C#</p>
      <p>- LINQ</p>
      <hr>
      <h2>Прочее</h2>
      <p>- Репозитории</p>
      <p>- Интерфейсы</p>
      <p>- MVC</p>
      <p>- HTTP</p>
      <p>- MVVM</p>
      <p>- WebApi</p>
      <p>- Модель, Параметр, Сущности</p>
      <hr>
    </div>
  </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";

@Component({
  components: {},
})
export default class Tehknology extends Vue { }
</script>

<style>
hr {
  border: none;
  background-color: black;
  height: 2px;
}
h2 {
  margin-top: 20px;
}

.table-data {
  width: 100%;
  margin-bottom: 20px;
  border: 1px solid #dddddd;
  border-collapse: collapse;
  font-size: 22px;
  margin-top: 25px;
}

.table-data tr {
  padding: 5px 0;
}

.table-data th {
  font-weight: bold;
  padding: 15px;
  background: #efefef;
  border: 1px solid #dddddd;
  text-align: center;
}

.table-data th img {
  height: 100px;
}

.table-data td {
  border: 1px solid #dddddd;
  padding: 15px;
  text-align: center;
}

.filtr-block {
  margin-top: 10px;
  margin-bottom: 30px;
}

.content-select {
  height: 40px;
  width: 250px;
  font-size: 20px;
  border: 1px solid silver;
  border-radius: 5px;
}

.content-find {
  width: 200px;
  height: 42px;
  margin-left: 30px;
  float: right;
  background-color: white;
  border-radius: 5px;
  border: 1px solid silver;
  font-size: 18px;
  cursor: pointer;
}
</style>
