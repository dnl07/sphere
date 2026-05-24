import { useState } from "react"
import ConfirmDialog from "../../../../shared/components/ConfirmDialog"
import { useDeleteClothingItem } from "../../../clothing/hooks/useDeleteClothingItem"
import { useLocation, useNavigate } from "react-router"
import { Pencil, Trash2 } from "lucide-react"

type Props = {
    itemId: string
    toUpdate: boolean
    setToUpdate: (toUpdate: boolean) => void
    update: () => void
}

const ItemActions = ({ itemId, toUpdate, setToUpdate, update }: Props) => {
    const navigate = useNavigate()
    const location = useLocation()

    const [showDialog, setShowDialog] = useState<boolean>(false)
    const { deleteItem } = useDeleteClothingItem()

    const handleEditToggle = () => {
        if (toUpdate) {
            update()
        } else {
            setToUpdate(true)
        }
    }

    const handleDeleteOrCancel = () => {
        if (toUpdate) {
            setToUpdate(false)
        } else {
            setShowDialog(true)
        }
    }

    return (
        <>
            <div className="flex flex-row w-full mb-4 gap-4">
                <button
                    className={`bg-black w-full text-white  py-2 px-4 rounded-lg cursor-pointer transition-all duration-150 ${toUpdate ? "flex-1" : "flex-3"}`}
                    onClick={handleEditToggle}
                >
                    {toUpdate ? (
                        <span>Update</span>
                    ) : (
                        <div className="flex justify-center items-center gap-2">
                            <Pencil size={20} />
                            <span>Edit</span>
                        </div>
                    )}
                </button>
                <button
                    className={`bg-red-100 w-full flex-1 py-2 px-4 rounded-lg text-red-400 cursor-pointer transition-all duration-150 ${toUpdate ? "flex-3" : "flex-1"}`}
                    onClick={handleDeleteOrCancel}
                >
                    {toUpdate ? (
                        <span>Cancel</span>
                    ) : (
                        <div className="flex justify-center items-center gap-2 font-semibold">
                            <Trash2 size={20} />
                            <span>Delete</span>
                        </div>
                    )}{" "}
                </button>
            </div>
            {showDialog && (
                <ConfirmDialog
                    message="Are you sure you want to delete this item?"
                    onConfirm={async () => {
                        await deleteItem(itemId)
                        navigate(location.state?.from ?? -1, { replace: true })
                    }}
                    onCancel={() => setShowDialog(false)}
                />
            )}
        </>
    )
}

export default ItemActions
