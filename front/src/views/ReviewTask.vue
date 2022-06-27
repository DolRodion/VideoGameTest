<template>
  <div>
    <div class="content-title">
      <h1>Техническое задание</h1>
    </div>

    <div class="content-inp">
      <h2>Задание</h2>
      <p>Сделать web api для взаимодействия с базой данных, в которой хранятся данные о видеоиграх. Информация о игре: название, студия разработчик, несколько жанров, которым соответствует игра.</p>
      <h2>Дополнительно:</h2>
      <p>- реализовать CRUD операции с ней;</p>
      <p>- реализовать метод для получения списка игр определённого жанра;</p>
      <p>- используемые технологии: NET core, EntityFramework;</p>
      <p>- требуется наличие: SOLID, MVC, MVVM.</p>
      <h2>Комментарий</h2>
      <p>- Сделать минимум 3 слоя абстракций, а контроллеры "тонкими".</p>
    </div>
  </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";

@Component({
  components: {},
})
export default class ReviewTask extends Vue {}
</script>

<style>
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

.table-data th img{
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

.content-find{
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
