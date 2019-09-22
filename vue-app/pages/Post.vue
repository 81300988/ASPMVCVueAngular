<template>
    <div>
        <div class="post" v-if="selectedBlog" >
            <header>{{selectedBlog.title}}</header>
            <div>{{selectedBlog.body}}</div>
        </div>
        <div v-else>
            loading blogs...
        </div>
        <router-link to="/"> I am done reading</router-link>
    </div>
</template>

<script>
import {mapState, mapActions} from 'vuex';
export default {
    created(){
        this.loadBlog(this.$route.params.id);
    },
    methods: {
        ...mapActions(["loadBlog"]),
        clearBlog(){
        this.$store.commit("clearBlog");
        }
    },
    computed: mapState(["selectedBlog"])
}
</script>

<style>
.post{
        display: block;
    }
</style>
