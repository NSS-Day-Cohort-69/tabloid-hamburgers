import { useEffect } from "react"
import { useParams } from "react-router-dom"

const UserIsAuthor = ({ children }) =>
{
    const { postId } = useParams()

    useEffect(
        () =>
        {

        }, [postId]
    )
}