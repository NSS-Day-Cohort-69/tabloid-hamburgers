import { useEffect, useState } from "react";
import { deleteTagById, getAllTags } from "../../managers/tags";
import { useNavigate } from "react-router-dom";

export const TagsView = () => {
  const [allTags, setAllTags] = useState([]);
  const navigate = useNavigate();

  const getTagsData = () => {
    getAllTags().then(setAllTags);
  };

  useEffect(() => {
    getTagsData();
  }, []);

  return (
    <main>
      <div>
        <button
          onClick={() => {
            navigate(`create`);
          }}
        >
          Create
        </button>
        {allTags.map((t) => {
          return (
            <article key={t.id}>
              {t.tagName}{" "}
              <button
                onClick={() => {
                  if (window.confirm(`Confirm delete for: ${t.tagName}`)) {
                    deleteTagById(t.id).then(() => {
                      getTagsData();
                    });
                  }
                }}
              >
                Delete
              </button>
            </article>
          );
        })}
      </div>
    </main>
  );
};
