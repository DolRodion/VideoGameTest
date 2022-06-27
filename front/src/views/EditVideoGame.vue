<template>
  <div>
    <v-form>
      <h1>Редактирование игры</h1>
      <div v-if="getData != null">
        <p>Название игры</p>
        <v-text-field v-model.trim="getData.GameName"> </v-text-field>
        <p>Студия разработчик</p>
        <v-text-field v-model.trim="getData.StudioDeveloper"> </v-text-field>
        <p>Url картинки</p>
        <v-text-field v-model.trim="getData.GamePicture"> </v-text-field>
        <p>Жанр/ы игры</p>
        <v-text-field v-model.trim="getData.GameType"> </v-text-field>
      </div>
      <br>
      <br>
      <v-btn @click="EditVideoGame()" class="inputAddCheck">Сохранить</v-btn>
    </v-form>
  </div>
</template>

<script lang="ts">
import { Component, Prop, Vue } from 'vue-property-decorator';
import { VideoGameModel, FormAddVideoGameParams, AdminService } from '@/AxiosSetup/service';
import router from '@/router';


@Component({
  components: {
  },
})
export default class AddVideoGame extends Vue {
  @Prop() id!: number | string;
  private data?: VideoGameModel | null = null;
  public dataform: FormAddVideoGameParams = new FormAddVideoGameParams();
  
  async created() {
    try {
      this.data = await AdminService.GetVideoGameById(this.id as number);
 
    }
    catch (e) {
      alert("Произошла ошибка при получении записи.");
    }
  }

  public async EditVideoGame() {
    
    this.dataform.Id = this.data?.Id;
    this.dataform.GameName = this.data?.GameName;
    this.dataform.GamePicture = this.data?.GamePicture;
    this.dataform.StudioDeveloper = this.data?.StudioDeveloper;
    this.dataform.GameType = this.data?.GameType;

    debugger;

    if((!this.dataform.GameName || 0 === this.dataform.GameName.length) || (!this.dataform.StudioDeveloper || 0 === this.dataform.StudioDeveloper.length) || (!this.dataform.GameType || 0 === this.dataform.GameType.length))
    {
      alert("Заполните все поля *");
      return false;
    }

    try {
      const result = await AdminService.EditVideoGame(this.dataform);

      if (result) {
        router.push({ path: '/Admin/Game' })
        location.reload();
      }
    }

    catch (e) {
      alert("Произошла ошибка при редактировании записи.");
    }
    
    }

  get getData() {
    
    return this.data;
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