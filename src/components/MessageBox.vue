<template>
    <div>
        <div class="boxContainer">
            <h2>Message Box</h2>
            <p>Leave an anonymous message, or pick up a few to see what people are dropping off.</p>
            <div id="usrOptions">
                <input type="text" id="inboundMessage_TextBox" v-model="post"/>
                <button type="Submit" id="submitMessage_Btn" @click="addPost">Leave my message!</button>
            </div>
        </div>
        <div class="boxContainer">
            <ul>
                <li class="usrPost" v-for="item in  this.posts" :key="item">
                    {{item}}
                </li>
            </ul>
        </div>
    </div>
</template>

<script>
export default {
    data() {
        return {
            post: "",
            posts : [],
        }
    },
    methods: {
        addPost() {
            this. posts.push(this.post);
        }
    }
}
</script>

<style>
ul {
    padding: 0px 5px 0px 5px;
}

.boxContainer {
    border: solid blueviolet 8px;
    border-radius: 6px;
    background:gray;
    margin: 25px 30% 25px 30%;
    align-content: center
}

#submitMessage_btn {
    padding-left: 15px;
}

#usrOptions {
    display: flexbox;
    flex-direction: column;
}

li{
    list-style: none;
    padding-left: 0;
}

</style>

