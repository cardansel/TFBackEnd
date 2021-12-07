export function ShowCount(props){
    const [count,setCount]=useState();

    useEffect(()=>{
        setCount(props.count);

    },[props.count]);

    return (
        <div>
            <h1>Count: {count}</h1>
        </div>
    );

}