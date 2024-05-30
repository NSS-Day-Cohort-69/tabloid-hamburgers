import { useContext, useEffect, useState } from "react"
import { useParams } from "react-router-dom"
import { UserContext } from "../App"

const UserIsAuthor = ({ children }) =>
{
    const user = useContext(UserContext)
    const { postId } = useParams()
    const [post, setPost] = useState({})

    useEffect(
        () =>
        {
            
        }, [postId]
    )

    return user.id == postId
        ? <>{children}</>
        : <>You do not own this post.</>
}

export default UserIsAuthor