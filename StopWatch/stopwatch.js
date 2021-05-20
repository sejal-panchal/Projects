function StopWatch()
{
    let running=false;
    let strttime,endtime;
    let duration=0;

    this.start= function(){
        if(running) throw new Error('Stopwatch already running!');

        running=true;
        strttime=new Date();
       
        
    };
    this.stop=function(){
        if(!running) throw new Error('Stopwatch is not started!');

        running=false;
       endtime=new Date();
       
       const totaltime = (endtime.getTime() - strttime.getTime())/1000;
       duration+=totaltime;
    };
    this.reset=function(){
        strttime=null;
        endtime=null
        duration=0;
       running=false;

    };
    
    
    

    Object.defineProperty(this,'duration',{
        get: function(){
            //this lets you get the property. read only property; do not set setter
            return duration;
        }
    });

}

const sw =new StopWatch();
