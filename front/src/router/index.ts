import Vue from 'vue';
import VueRouter, { RouteConfig } from 'vue-router';
import Home from '../views/Home.vue';
import ReviewTask from '../views/ReviewTask.vue';
import Tehknology from '../views/Tehknology.vue';
import AdminPage from '../views/AdminPage.vue';
import AddVideoGame from '../views/AddVideoGame.vue';
import EditVideoGame from '../views/EditVideoGame.vue';


Vue.use(VueRouter);

const routes: RouteConfig[] = [
  {
    path: '/',
    name: 'Home',
    component: Home,
  },
  {
    path: '/Home/ReviewTask',
    name: 'ReviewTask',
    component: ReviewTask,
  },
  {
    path: '/Home/Tehknology',
    name: 'Tehknology',
    component: Tehknology,
  },
  {
    path: '/Admin/Game',
    name: 'AdminPage',
    component: AdminPage,
  },
  {
    path: '/Admin/addVideoGame',
    name: 'AddVideoGame',
    component: AddVideoGame,
  },

  {
    path: '/Admin/editVideoGame',
    name: 'EditVideoGame',
    component: EditVideoGame,
  },

  {
    path: '/Admin/editVideoGame/:id',
    name: 'EditVideoGame',
    props: true,
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import(/* webpackChunkName: "about" */ '../views/EditVideoGame.vue'),
  },

];

const router = new VueRouter({
  routes,
});

export default router;
