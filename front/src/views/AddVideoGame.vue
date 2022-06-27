<template>
  <div>
    <v-form>
      <h1>Добавление новой игры</h1>
      <p>Название игры*</p>
      <v-text-field v-model.trim="data.GameName"> </v-text-field>
      <p>Студия разработчик*</p>
      <v-text-field v-model.trim="data.StudioDeveloper"> </v-text-field>
      <p>Url картинки</p>
      <v-text-field v-model.trim="data.GamePicture"> </v-text-field>
      <p>Жанр/ы игры*</p>
      <v-text-field v-model.trim="data.GameType"> </v-text-field>
      <br>
      <br>
      <v-btn @click="AddVideoGame()" class="inputAddCheck">Добавить игру</v-btn>
    </v-form>
  </div>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator';
import { FormAddVideoGameParams, AdminService } from '@/AxiosSetup/service';
import router from '@/router';


@Component({
  components: {
  },
})
export default class AddVideoGame extends Vue {
  public data: FormAddVideoGameParams = new FormAddVideoGameParams();
  
  public async AddVideoGame() {

    if((!this.data.GameName || 0 === this.data.GameName.length) || (!this.data.StudioDeveloper || 0 === this.data.StudioDeveloper.length) || (!this.data.GameType || 0 === this.data.GameType.length))
    {
      alert("Заполните все поля *");
      return false;
    }

    const result = await AdminService.AddVideoGame(this.data);
      if (result) {
        router.push({ path: '/Admin/Game' })
      }
    }
 

  }


</script>

<style>
input {
    width: 250px;
    height: 20px;
}

h1 {
    margin-bottom: 30px;
}

p {
    font-size: 20px;
    margin: 20px 0 10px 0;
}

button {
    width: 250px;
    height: 30px;
    font-size: 15px;
}



.inputAddVideoGame {
  width: 178px;
  border: 1px solid #0db3e3 !important;
  font-size: 1px;
  color: #0db3e3;
  background-color: white;
  padding: 5px 5px;
  cursor: pointer;
}


.inputAddVideoGame:hover {
  background-color: #0db3e3;
  color: white;
  transition: 0.5s;
}
</style>