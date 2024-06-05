import { Fragment, useContext, useEffect, useState } from "react";
import { getPublicPosts } from "../managers/postManager";
import { Link } from "react-router-dom";
import { UserContext } from "../App";
import "./PostView.css";
import { getAllCategories } from "../managers/categories";
import { getAllTags } from "../managers/tags";

const PostList = () => {
  const user = useContext(UserContext);
  const [filterSettings, setFilterSettings] = useState({
    Category: 0,
    Tag: 0,
  });
  const [posts, setPosts] = useState([]);
  const [filteredPosts, setFilteredPosts] = useState([]);
  const [categories, setCategories] = useState([]);
  const [tags, setTags] = useState([]);

  useEffect(() => {
    getAllTags().then(setTags);
  }, []);

  useEffect(() => {
    getAllCategories().then(setCategories);
  }, []);

  useEffect(() => {
    getPublicPosts().then((posts) => {
      setPosts(
        posts.sort((a, b) => new Date(b.publication) - new Date(a.publication))
      );
    });
  }, []);

  useEffect(() => {
    setFilteredPosts(posts.filter(
      p => (p.categoryId == filterSettings.Category || filterSettings.Category == 0)
      && (p.postTags.some((pt) => pt.tagId == filterSettings.Tag) || filterSettings.Tag == 0)
    ))
    // if (filterSettings.Category == 0 && filterSettings.Tag == 0) {
    //   setFilteredPosts(posts);
    // } else {
    //   const copy = [...posts];
    //   switch (true) {
    //     case filterSettings.Category != 0 && filterSettings.Tag == 0:
    //       return setFilteredPosts(
    //         copy.filter((c) => c.categoryId === filterSettings.Category)
    //       );
    //     case filterSettings.Tag != 0 && filterSettings.Category == 0:
    //       return setFilteredPosts(
    //         copy.filter((cObj) =>
    //           cObj.postTags.some((pt) => pt.tagId == filterSettings.Tag)
    //         )
    //       );
    //     case filterSettings.Category != 0 && filterSettings.Tag != 0:
    //       return setFilteredPosts(
    //         copy.filter(
    //           (cObj) =>
    //             cObj.postTags.some((pt) => pt.tagId == filterSettings.Tag) &&
    //             cObj.categoryId === filterSettings.Category
    //         )
    //       );
    //   }
    // }
  }, [filterSettings, posts]);

  return (
    <main>
      <div className="PostList-div-maincontainer">
        <select
          defaultValue={0}
          onChange={(e) => {
            const copy = { ...filterSettings };
            copy.Category = parseInt(e.target.value);
            setFilterSettings(copy);
          }}
        >
          <option value={0}>--All Categories--</option>
          {categories.map((c) => {
            return (
              <option key={c.id} value={c.id}>
                {c.categoryName}
              </option>
            );
          })}
        </select>
        <select
          defaultValue={0}
          onChange={(e) => {
            const copy = { ...filterSettings };
            copy.Tag = parseInt(e.target.value);
            setFilterSettings(copy);
          }}
        >
          <option value={0}>--No Tags--</option>
          {tags.map((t) => {
            return (
              <option key={t.id} value={t.id}>
                {t.tagName}
              </option>
            );
          })}
        </select>
        <section className="PostList-section-posts">
          {filteredPosts.map((p) => (
            <article key={"p" + p.id} className="PostList-post-border">
              <header className="PostList-post-header">
                {p.publication}{" "}
                {p.authorId == user.id && (
                  <Link to={`/post/${p.id}/edit`}>edit</Link>
                )}
              </header>
              {p.imageURL == null || "" ? (
                <img
                  src={
                    "https://resources.alleghenycounty.us/css/images/Default_No_Image_Available.png"
                  }
                />
              ) : (
                <img src={p.imageURL} />
              )}
              <div>
                <Link to={`/post/${p.id}`} className="PostList-linkto-post">
                  <div>{p.title}</div>
                </Link>

                <Link to={`/userprofiles/${p.authorId}`} className="PostList-linkto-post">
                <div>{p.author.fullName}</div>
                </Link>

                <div>{p.category.categoryName}</div>
              </div>
            </article>
          ))}
        </section>
      </div>
    </main>
  );
};

export default PostList;
