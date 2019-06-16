<template>
    <div>
        <div class="boxContainer">
            <h2>Message Box</h2>
            <p>Leave an anonymous message, or pick up a few to see what people are dropping off.</p>
            <div id="usrOptions">
                <input type="text" id="inboundMessage_TextBox"/>
                <button type="Submit" id="submitMessage_Btn">Leave my message!</button>
            </div>
        </div>
        <div class="boxContainer">
            <ul>
                <li class="usrPost">
                    <p>UsrName</p>
                    <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Praesentium similique sunt aliquam magnam nemo quibusdam incidunt dolores autem quos ut consectetur harum maiores quo earum alias iste, cupiditate quisquam aspernatur?</p>
                </li>
            </ul>
        </div>
    </div>
</template>
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
