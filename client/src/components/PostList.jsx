import { useEffect, useState } from "react"
import { getPublicPosts } from "../managers/postManager"

const PostList = () =>
{
    const [posts, setPosts] = useState([])

    useEffect(
        () =>
        {
            getPublicPosts().then(setPosts)
        }, []
    )

    return <>post list</>
}

export default PostList