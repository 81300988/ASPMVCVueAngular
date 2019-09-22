<template>
    <div class="app">
        <h1>Mega Blog</h1>
        <router-view></router-view>
    </div>
</template>>

<script>

export default {
    data: function(){
        return {
            blogs: []
        }
    },
    created: function(){}
}
</script>

<style>
    html{
        background: azure;
    }
    body{
        margin: 0;
    }
    .card{
        display: block;
    }
    .post{
        display: block;
    }
    .app{
        margin: 5%;
        justify-content: center;
    }
    .app > div{
        max-width: 400;
        width: 100%;
    }
    .card{
        margin-top: 0.5rem;
        background-color: bisque;
        box-shadow: 0 1px 2px 0 #444;
    }
</style>