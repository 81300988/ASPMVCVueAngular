<template>
    <div>
        <router-link class="card" v-for="blog in blogs" :key="blog.id" :to="`/${blog.id}`">
            <header>{{blog.title}}</header>
            <div>{{blog.body}}</div>
        </router-link >
    </div>
</template>

<script>
import {mapState} from "vuex";
export default {
    created(){
        this.$store.dispatch('loadBlogs');
    },
    computed: mapState(["blogs"])
}
</script>

<style>

</style>
