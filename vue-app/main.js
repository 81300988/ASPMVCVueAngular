import Vue from "vue";
import App from "./App.vue";
import Vuex from "vuex";
import VueRouter from "vue-router";
import Axios from 'axios';

import Main from "./pages/Main.vue";
import Post from "./pages/Post.vue";

Vue.use(Vuex);
Vue.use(VueRouter);

export function createApp(){

    const store = new Vuex.Store({
        state:{
            blogs:[],
            selectedBlog: null
        },
        mutations:{
            saveBlogs(state, blogs){
                state.blogs = blogs;
            },
            saveBlog(state, blog){
                state.selectedBlog = blog;
            },
            clearBlog(state){
                state.selectedBlog = null;
            }
        },
        actions:{
            loadBlogs({commit}, origin)
            {
                if(origin === null || origin === undefined){
                    origin = ""
                }
                return Axios.get(`${origin}/Blog`).then(res =>
                    {
                        commit('saveBlogs', res.data)
                    })
            },
            loadBlog({commit}, id){
                return Axios.get(`/blog/${id}`).then(res => {
                    commit('saveBlog', res.data)
                })
            }
            
        }
    })
    
    const router = new VueRouter({
        mode:'history',
        routes: [
            {
                path: '/',
                component: Main
            },
            {
                path:'/:id',
                component: Post
            }
        ]
    })
    const app = new Vue({
        store,
        router,
        render: h => h(App)
    });
    
    return {
        app,
        router,
        store
    }
} 
